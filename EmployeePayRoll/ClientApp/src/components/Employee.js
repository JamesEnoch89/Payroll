import React from "react";
import axios from 'axios';

const Employee = (props) => {
  const employee = props.employee;

  const toggleDependentsTable = () => {
    props.fetchDependents(
      {
        show: true,
        employee: employee
      });
  }

  const deleteEmployee = async () => {
    axios.delete(`api/payroll/delete/employee/${employee.Id}`);
    let activeEmployees = props.employees.filter(emp => emp.Id !== employee.Id);
    props.setEmployees(activeEmployees);
  };

  const stringifyDecimal = (decimal) => {
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
      <td><i className="bi bi-x" onClick={deleteEmployee}></i></td>
    </tr>
  );
};

export default Employee;