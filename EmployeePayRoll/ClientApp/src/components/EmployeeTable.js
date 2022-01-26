import React, { useState, useMemo } from "react";
import Employee from "./Employee";
import EmployeeDependents from "./EmployeeDependents";

const EmployeeTable = ({ employees }) => {
  debugger;
  const [showDependents, setShowDependents] = useState(false);

  const shouldShowDependents = (data) => {
    debugger;
    console.log(data);
    setShowDependents(data);
  }
  //const employee = props.employee;

  //const toggleDependentsTable = () => {
  //  debugger;
  //  props.showDependents(true);
  //}

  return (
    <div>
      <table className="table table-sm table-bordered table-striped">
        <thead>
          <tr className="text-center">
            <th scope="col">Employee Name</th>
            <th scope="col">Pay <br />Per Period</th>
            <th scope="col">Total Pay</th>
            <th scope="col">Deductions <br />Per Period</th>
            <th scope="col">Total Deductions</th>
            <th scope="col">Dependents</th>
            <th scope="col">Add<br /> Dependent</th>
            <th scope="col">Delete <br />Employee</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <Employee
              key={employee.Id}
              employee={employee}
              showDependents={shouldShowDependents}
            />
          ))}

        </tbody>
      </table>

    {/*  <EmployeeDependents showDependents={showDependents} />*/}
    </div>


  );
};

export default EmployeeTable;