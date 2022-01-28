import React, { useState, useEffect } from "react";
import EmployeeTable from "./components/EmployeeTable";
import AddEmployee from "./components/AddEmployee";
import EmployeeDependents from "./components/EmployeeDependents";
import axios from 'axios';
import "./App.css";

const App = () => {
  const [employees, setEmployees] = useState([]);
  const [showDependentData, setShowDependentData] = useState({});
  const [shouldUpdateEmployees, setShouldUpdateEmployees] = useState(false);

  useEffect(() => {
    debugger;
    const getEmployees = async () => {
      const res = await axios.get('api/payroll/get/employees');
      const { data } = await res;

      setEmployees(data);

      setShouldUpdateEmployees(false);
    };

    if (!employees.length || shouldUpdateEmployees) {
      getEmployees();
    }

  }, [shouldUpdateEmployees]);

  // callback function to show dependents grid and set employee id to search on
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
          fetchDependents={fetchDependentTableData}
          setEmployees={setEmployees}
          setShouldUpdateEmployees={setShouldUpdateEmployees}/>
      </form>
      {!showDependentData.show ? null :
        <EmployeeDependents showDependentData={showDependentData}
          setShowDependentData={setShowDependentData}
          employees={employees}
          setShouldUpdateEmployees={setShouldUpdateEmployees}
          shouldUpdateEmployees={shouldUpdateEmployees} />}
    </div>
  );
};

export default App;