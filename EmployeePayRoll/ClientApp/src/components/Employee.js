import React, { useState } from "react";

const Employee = (props) => {
  debugger;
  const employee = props.employee;
  //const [showDependents, setShowDependents] = useState(false);

  const toggleDependentsTable = () => {
    props.fetchDependents(
      {
        show: true,
        employee: employee
      });
  }

  const stringifyDecimal = (decimal) => {
    debugger;
    return decimal.toLocaleString();
  }

  return (
    <tr className="text-center">
      <td>{employee.Name}</td>
      <td>${stringifyDecimal(employee.PayPerPeriod)}</td>
      <td>${employee.DeductionPerPeriod + employee.DependentDeductionAmountPerPeriod}</td>
      <td>${stringifyDecimal(employee.GrossPay)}</td>
      <td>${stringifyDecimal(employee.TotalEmployeeDeductionAmount + employee.TotalDependentDeductionAmount)}</td>
      <td>${stringifyDecimal(employee.GrossPay - (employee.TotalDependentDeductionAmount + employee.TotalEmployeeDeductionAmount))}</td>
      <td>
        <i className="bi bi-search" onClick={toggleDependentsTable}></i>
      </td>
      <td><i className="bi bi-x"></i></td>
    </tr>
  );
};

export default Employee;