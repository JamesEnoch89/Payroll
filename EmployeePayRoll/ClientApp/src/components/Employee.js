import React from "react";

const EmployeeRow = ({ employee }) => {
  debugger;
  return (
    <tr className="text-center">
      <td>{employee.Name}</td>
      <td>{employee.PayPerPeriod}</td>
      <td>{employee.TotalPay}</td>
      <td>{employee.DeductionAmount}</td>
      <td>{employee.TotalDeductionAmount}</td>
      <td><i className="bi bi-caret-down-fill"></i></td>
    </tr>
  );
};

export default EmployeeRow;