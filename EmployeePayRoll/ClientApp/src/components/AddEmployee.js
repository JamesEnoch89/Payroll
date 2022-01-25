import React, { useState } from "react";
import axios from 'axios';

const AddEmployee = ({ setEmployees }) => {
  const employee = {
    Id: 0,
    Name: "",
    PayPerPeriod: 0,
    TotalPay: 0,
    DeductionTypeId: 0
  };

  const [searchTerm, setSearchTerm] = useState("");

  const handleEmployeeInput = event => {
    debugger;
    const searchTerm = event.target.value;
    setSearchTerm(searchTerm);
  };

  const saveEmployee = async () => {
    debugger;
    employee.Name = searchTerm;

    const resp = await axios.post('api/payroll/create/employee', employee);
    const allEmployees = resp.data;
    setEmployees(allEmployees);
    setSearchTerm("");
  };

return (
  <div className="form-group">
    <label htmlFor="employeeName">Employee Name</label>
    <div className="row">
      <input
        className="form-control col-sm-2"
        type="text"
        name="name"
        required="required"
        placeholder="Enter employee name"
        onChange={handleEmployeeInput}
        value={searchTerm}
        id="employeeName"
      />
      <button type="submit" className="btn" onClick={saveEmployee}><i className="bi bi-person-plus-fill"></i></button>
    </div>
  </div>
);
};


export default AddEmployee;