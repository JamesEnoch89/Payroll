import React, { useState, useEffect } from "react";
import "./App.css";
import EmployeeTable from "./components/EmployeeTable";
import AddEmployee from "./components/AddEmployee";
import EmployeeDependents from "./components/EmployeeDependents";
import axios from 'axios';

const App = () => {
  const [employees, setEmployees] = useState([]);
  const [showDependentData, setShowDependentData] = useState({});

  useEffect(() => {
    const getEmployees = async () => {
      const res = await axios.get('api/payroll/get/employees');
      const { data } = await res;

      setEmployees(data);
    };

    if (!employees.length) {
      getEmployees();
    }

  }, [employees]);

  const fetchDependentTableData = (data) => {
    setShowDependentData(data);
  }

  return (
    <div className="app-container col-10">
      <header className="text-center">
        <h1><i className="bi bi-piggy-bank"></i > Employee Payroll <i className="bi bi-piggy-bank"></i></h1>
      </header>
      <AddEmployee setEmployees={setEmployees} />
      <form>
        <EmployeeTable 
          employees={employees}
          fetchDependents={fetchDependentTableData}/>
      </form>
      {!showDependentData.show ? null :
        <EmployeeDependents showDependentData={showDependentData}
          setShowDependentData={setShowDependentData}
          employees={employees} />}
    </div>
  );
};

export default App;