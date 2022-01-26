import React from "react";

const Employee = (props) => {
  debugger;
  const employee = props.employee;

  const toggleDependentsTable = () => {
    debugger;
    props.showDependents(true);
  }

  return (
    <tr className="text-center">
      <td>{employee.Name}</td>
      <td>${employee.PayPerPeriod}</td>
      <td>${employee.FormattedTotalPay}</td>
      <td>${employee.DeductionPerPeriod}</td>
      <td>${employee.FormattedTotalDeductionAmount}</td>
      <td>Test</td>
      <td className="flex-row col-2">
        <input type="text" className="col-9 mr-1" placeholder="Dependent Name" aria-label="Dependent" />
        <i className="bi bi-person-plus-fill"></i>
      </td>
      <td><i className="bi bi-x"></i></td>
    </tr>
  );
};

export default Employee;