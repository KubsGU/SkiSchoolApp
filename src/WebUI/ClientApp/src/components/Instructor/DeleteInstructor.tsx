import { useEffect, useState } from "react";
import { Trainers } from "types/types";
import s from "./../../App.module.scss";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const DeleteInstructor = () => {
  const [instructors, setInstructors] = useState<Trainers>();
  const [instructorId, setinstructorId] = useState<number | undefined>();
  const [reload, setReload] = useState(false);
  const notifySuccess = () => {
    toast.success("Pomyślnie usunięto instruktora");
  };
  const notifyError = () => {
    toast.error("Wystąpił problem. Spróbuj ponownie");
  };

  const handleDelete = async (e: any) => {
    e.preventDefault();

    try {
      await fetch(`${process.env.REACT_APP_IP}/Trainers/${instructorId}`, {
        method: "DELETE",
      });
      notifySuccess();
      setReload(true);
    } catch (e) {
      notifyError();
      console.log(e);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/api/Trainers`);
        const res = await data.json();
        setInstructors(res);
        setinstructorId(res.items[0].id);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, [reload]);

  return (
    <div>
      <p className={s.title}>Usuń Instruktora</p>

      <div className={s.selectContainer}>
        <select onChange={(e) => setinstructorId(+e.target.value)}>
          {instructors &&
            instructors.items.map((op) => {
              return (
                <option key={op.id} value={op.id}>
                  {`${op.name} ${op.surname}, ${op.price}zł`}
                </option>
              );
            })}
        </select>

        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleDelete}
        >
          remove
        </button>
      </div>
      <ToastContainer
        position="bottom-right"
        autoClose={2500}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
    </div>
  );
};

export default DeleteInstructor;
