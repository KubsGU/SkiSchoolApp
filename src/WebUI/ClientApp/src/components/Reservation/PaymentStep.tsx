import { FC } from "react";
import s from "./../../App.module.scss";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const PaymentStep: FC<{
  timetableId: number | undefined;
  rentalId: number | undefined;
  price: number;
  setStep: (page: number) => void;
}> = ({ timetableId, rentalId, price, setStep }) => {
  const notifySuccess = () => {
    toast.success("Pomyślnie opłacono rezerwacje");
  };
  const notifyError = () => {
    toast.error("Wystąpił problem. Spróbuj ponownie");
  };
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

    try {
      await fetch(`${process.env.REACT_APP_IP}/Payments`, {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body),
      });
      notifySuccess();
      setTimeout(() => {
        setStep(0);
      }, 3000);
    } catch (e) {
      notifyError();
      console.log(e);
    }
  };

  return (
    <>
      <p className={s.title}>Opłacenie</p>
      <button onClick={handlePayment}>Oplać</button>
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
    </>
  );
};

export default PaymentStep;
