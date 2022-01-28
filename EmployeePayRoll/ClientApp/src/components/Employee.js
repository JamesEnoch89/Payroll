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
    const res = await axios.delete(`api/payroll/delete/employee/${employee.Id}`);
    const deletedEmployeeId = res.data;

    let activeEmployees = props.employees.filter(emp => emp.Id !== deletedEmployeeId);
    props.setEmployees(activeEmployees);
    props.setShouldUpdateEmployees(true);
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