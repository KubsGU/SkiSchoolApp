import { useState } from "react";
import { SelectOptions } from "types/types";
import s from "./../../App.module.scss";

type ReportSelectOptions = SelectOptions & { type: string };

const RaportOptions: ReportSelectOptions[] = [
  { id: 1, type: "rental", label: "Raport dobowy (wypozyczenia)" },
  { id: 2, type: "timetable", label: "Raport dobowy (instruktorzy)" },
];

const Raport = () => {
  const [report, setReport] = useState<string>();
  const [reportType, setReportType] = useState<string>(RaportOptions[0].type);

  const generateReport = async (e: any) => {
    try {
      const data = await fetch(
        `${process.env.REACT_APP_IP}/reports/${reportType}`,
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ name: "raport" }),
        }
      );
      const res = await data.text();
      await downloadReport(res);
    } catch (e) {
      console.log(e);
    }
  };

  const downloadReport = async (raportId: string) => {
    try {
      const data = await fetch(
        `${process.env.REACT_APP_IP}/reports/downloadBlob/${raportId}`
      );
      const res = await data.text();
      const objectURL = window.URL.createObjectURL(
        new Blob([res], { type: "text/csv" })
      );
      setReport(objectURL);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <div>
      <p className={s.title}>Generuj raport</p>

      <div className={s.selectContainer}>
        <select
          onChange={(e) => {
            setReportType(e.target.value);
          }}
        >
          {RaportOptions.map((op) => {
            return (
              <option key={op.id} value={op.type}>
                {op.label}
              </option>
            );
          })}
        </select>
        <button className="material-icons" onClick={generateReport}>
          add_circle
        </button>

        {report && (
          <a
            className="material-icons link-repo"
            href={report}
            download="test.csv"
          >
            download
          </a>
        )}
      </div>
    </div>
  );
};

export default Raport;
