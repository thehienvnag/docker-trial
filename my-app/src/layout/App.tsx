import React from "react";
import { ListCourse } from "./ListCourse";
import logo from "../logo.svg";
import "../App.css";

const App = () => {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ListCourse />
      </header>
    </div>
  );
};

export default App;
