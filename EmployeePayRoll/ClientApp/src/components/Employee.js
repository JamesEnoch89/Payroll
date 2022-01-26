import React, { useState } from "react";

const Employee = (props) => {
  debugger;
  const employee = props.employee;
  const [showDependents, setShowDependents] = useState(false);

  const toggleDependentsTable = () => {
    debugger;
    props.fetchDependents(
      {
        show: true,
        employee: employee
      });
  }

  return (
    <tr className="text-center">
      <td>{employee.Name}</td>
      <td>${employee.PayPerPeriod}</td>
      <td>${employee.FormattedTotalPay}</td>
      <td>${employee.FormattedTotalPay}</td>
      <td>${employee.DeductionPerPeriod}</td>
      <td>${employee.FormattedTotalDeductionAmount}</td>
      <td>
        <i className="bi bi-search" onClick={toggleDependentsTable}></i>
      </td>
      <td><i className="bi bi-x"></i></td>
    </tr>
  );
};

export default Employee;