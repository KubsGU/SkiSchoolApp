import s from "./Navbar.module.scss";
import { navbarElements } from "./data";
import { useState } from "react";
import { Link } from "react-router-dom";
import logo from "./../../assets/logo.png";

const Navbar = () => {
  const [showId, setShowId] = useState<number>();
  const [activeId, setActiveId] = useState<string>();

  return (
    <div className={s.navbar}>
      <div className={s.logo}>
        <img src={logo} alt="logo"></img>
      </div>

      {navbarElements.map((el, i) => {
        return (
          <div key={i} onClick={() => setShowId(i)}>
            {el.children ? (
              <div className={s.title}>
                {el.name}
                {showId !==i && <i className="material-icons">keyboard_arrow_down</i> }
              </div>
            ) : (
              <Link
                key={i}
                to={`/${el.link}`}
                className={activeId === el.name ? s.activeLink : s.inactiveLink}
                onClick={() => setActiveId(el.name)}
              >
                {el.name}
              </Link>
            )}
            {showId === i ? (
              <div className={s.link__container}>
                {el.children?.map((elC, i) => {
                  return (
                    <Link
                      key={i}
                      to={`/${elC.link}`}
                      className={
                        activeId === el.name + elC.name
                          ? s.activeLink
                          : s.inactiveLink
                      }
                      onClick={() => setActiveId(el.name + elC.name)}
                    >
                      {elC.name}
                    </Link>
                  );
                })}
              </div>
            ) : null}
          </div>
        );
      })}
    </div>
  );
};

export default Navbar;
