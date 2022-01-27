import React, { useState, useEffect } from "react";
import AddDependent from "./AddDependent";
import axios from 'axios';

const EmployeeDependents = ({ showDependentData, setShowDependentData }) => {
  const [dependents, setDependents] = useState([]);

  useEffect(() => {
    debugger;
    const getDependents = async () => {
      let empId = showDependentData.employee.Id;
      const res = await axios.get(`api/payroll/get/employee/${empId}/dependents`);
      const { data } = await res;

      setDependents(data);
    };

    if (!dependents.length) {
      getDependents();
    }

  }, [dependents]);

  const closeDependents = () => {
    const data = {
      show: false,
      employee: showDependentData.employee
    };
    setShowDependentData(data);
  }

  return (
    <div>
      <h3 className="mb-3">Dependents for {showDependentData.employee.Name}</h3>
      <AddDependent setDependents={setDependents} employee={showDependentData.employee} />

      <table className="table table-sm table-bordered table-striped dependents-table">
        <thead>
          <tr className="text-center">
            <th scope="col">Dependent Name</th>
            <th scope="col">Deductions <br />Per Period</th>
            <th scope="col">Total Deductions</th>
          </tr>
        </thead>
        <tbody>
          {dependents.map((dependent) => (
            <tr className="text-center">
              <td>{dependent.Name}</td>
              <td>Test</td>
              <td>Test</td>
            </tr>
          ))}

        </tbody>
      </table>
      <button type="submit" className="btn col-1 close-button" onClick={closeDependents}>Close</button>
    </div>
  );
};

export default EmployeeDependents;
