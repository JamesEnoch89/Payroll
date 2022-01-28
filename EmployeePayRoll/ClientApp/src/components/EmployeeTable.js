import React from "react";
import Employee from "./Employee";

const EmployeeTable = ({ employees, fetchDependents, setEmployees, setShouldUpdateEmployees }) => {

  return (
    <div>
      <table className="table table-sm table-bordered table-striped">
        <thead>
          <tr className="text-center">
            <th scope="col">Employee Name</th>
            <th scope="col">Pay <br />Per Period</th>
            <th scope="col">Deductions <br />Per Period</th>
            <th scope="col">Gross Yearly Pay</th>
            <th scope="col">Total Deductions</th>
            <th scope="col">Net Pay</th>
            <th scope="col">View/Add<br /> Dependents</th>
            <th scope="col">Delete <br />Employee</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <Employee
              key={employee.Id}
              employee={employee}
              fetchDependents={fetchDependents}
              employees={employees}
              setEmployees={setEmployees}
              setShouldUpdateEmployees={setShouldUpdateEmployees}
            />
          ))}

        </tbody>
      </table>
    </div>
  );
};

export default EmployeeTable;