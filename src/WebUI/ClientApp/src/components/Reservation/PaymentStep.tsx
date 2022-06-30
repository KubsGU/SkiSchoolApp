import { FC } from "react";
import s from "./../../App.module.scss";

const PaymentStep: FC<{
  timetableId: number | undefined;
  rentalId: number | undefined;
  price: number;
  setStep: (page: number) => void;
}> = ({ timetableId, rentalId, price, setStep }) => {
  const handlePayment = async () => {
    const tzoffset = new Date().getTimezoneOffset() * 60000;
    const localISOTime = new Date(Date.now() - tzoffset)
      .toISOString()
      .slice(0, -1);

    const body = {
      price,
      rentalId: rentalId ?? null,
      timetableId: timetableId ?? null,
      status: true,
      date: localISOTime,
    };

    console.log(new Date(Date.now()).toISOString());
    try {
      await fetch(`${process.env.REACT_APP_IP}/Payments`, {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body),
      });
      setStep(0);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <>
      <p className={s.title}>Opłacenie</p>
      <button onClick={handlePayment}>Oplać</button>
      {/* <div className={s.add}>
        <button onClick={() => setStep(2)} form="instructorForm">
          Powrót
        </button>
      </div> */}
    </>
  );
};

export default PaymentStep;
