import React, { useState, useEffect } from "react";
import AddDependent from "./AddDependent";
import axios from 'axios';

const EmployeeDependents = ({ showDependentData, setShowDependentData, setShouldUpdateEmployees, shouldUpdateEmployees }) => {
  const [dependents, setDependents] = useState([]);

  useEffect(() => {
    const getDependents = async () => {
      const res = await axios.get(`api/payroll/get/employee/${showDependentData.employee.Id}/dependents`);
      const { data } = await res;

      setDependents(data);
    };

    if (!dependents.length || dependents.some(d => d.EmployeeId !== showDependentData.employee.Id) || shouldUpdateEmployees) {
      getDependents();
    }

  }, [showDependentData.employee.Id, shouldUpdateEmployees]);

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
      <AddDependent setDependents={setDependents} employee={showDependentData.employee} setShouldUpdateEmployees={setShouldUpdateEmployees}/>

      <table className="table table-sm table-bordered table-striped dependents-table">
        <thead>
          <tr className="text-center">
            <th scope="col">Dependent Name</th>
            <th scope="col">Deductions <br />Per Period</th>
            <th scope="col">Total Deductions</th>
          </tr>
        </thead>
        <tbody>
          {dependents.map((dependent) => {
            return <tr className="text-center" key={dependent.DependentId}>
              <td>{dependent.Name}</td>
              <td>${dependent.DeductionAmountPerPeriod}</td>
              <td>${dependent.DeductionAmount.toLocaleString()}</td>
            </tr>
          })}
        </tbody>
      </table>
      <button type="submit" className="btn col-1 close-button" onClick={closeDependents}>Close</button>
    </div>
  );
};

export default EmployeeDependents;
