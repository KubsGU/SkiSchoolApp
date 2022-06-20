import s from "./App.module.scss";
import background from "./assets/ski.jpeg";
import { Link } from "react-router-dom";

const App = () => {
  return (
    <div className={s.app}>
      <img src={background} alt="backgorund"></img>
    </div>
  );
};

export default App;
