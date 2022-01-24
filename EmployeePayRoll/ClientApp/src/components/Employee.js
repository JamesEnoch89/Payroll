import React from "react";

const EmployeeRow = ({ employee }) => {
  debugger;
  return (
    <tr>
      <td>{employee.Name}</td>
      <td>{employee.PayPerPeriod}</td>
      <td>{employee.TotalPay}</td>
      <td>{employee.Deduction.DeductionAmount}</td>
      <td>{employee.Deduction.TotalDeductionAmount}</td>
      <td><i className="bi bi-caret-down-fill"></i></td>
    </tr>
  );
};

export default EmployeeRow;