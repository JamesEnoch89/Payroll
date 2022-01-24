import React, { useState, useEffect } from "react";
import "./App.css";
import EmployeeRow from "./components/Employee";
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
      <AddEmployee />
      <form>

        <table className="table table-sm table-bordered table-striped">
          <thead>
            <tr>
              <th scope="col">Employee Name</th>
              <th scope="col">Pay Per Period</th>
              <th scope="col">Total Pay</th>
              <th scope="col">Deductions Per Period</th>
              <th scope="col">Total Deductions</th>
              <th scope="col">View Dependents</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((employee) => (
              <EmployeeRow
                key={employee.Id}
                employee={employee}
              />
            ))}
          </tbody>
        </table>
      </form>
    </div>
  );
};

export default App;