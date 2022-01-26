import React, { useState, useEffect } from "react";
import "./App.css";
import EmployeeTable from "./components/EmployeeTable";
import AddEmployee from "./components/AddEmployee";
import axios from 'axios';

const App = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    debugger;
    const getEmployees = async () => {
      const res = await axios.get('api/payroll/get/employees');
      const { data } = await res;

      setEmployees(data);
    };

    if (!employees.length) {
      getEmployees();
    }

  }, [employees]);


  return (
    <div className="app-container col-10">
      <header className="text-center">
        <h1><i className="bi bi-piggy-bank"></i > Employee Payroll <i className="bi bi-piggy-bank"></i></h1>
      </header>
      <AddEmployee setEmployees={setEmployees} />
      <form>
        <EmployeeTable 
          employees={employees} />
      </form>
    </div>
  );
};

export default App;