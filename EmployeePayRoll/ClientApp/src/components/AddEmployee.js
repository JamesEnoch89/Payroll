import React, { useState } from "react";
import axios from 'axios';

const AddEmployee = ({ setEmployees }) => {
  const [searchTerm, setSearchTerm] = useState("");

  const employee = {
    Id: 0,
    Name: "",
    PayPerPeriod: 0,
    TotalPay: 0,
    DeductionTypeId: 0,
    showDep: false
  };

  const handleEmployeeInput = event => {
    const searchTerm = event.target.value;

    setSearchTerm(searchTerm);
  };

  const saveEmployee = async () => {
    if (!searchTerm) {
      return alert('Please add a name!');
    }

    employee.Name = searchTerm;

    const resp = await axios.post('api/payroll/create/employee', employee);
    const allEmployees = resp.data;
    setEmployees(allEmployees);
    setSearchTerm("");
  };

  return (
    <div className="ml-3 row">
      <div className="input-group mb-3 col-3 mr-2">
        <input type="text" className="form-control" name="name" placeholder="Employee Name" aria-label="Employee" onChange={handleEmployeeInput} value={searchTerm} />
        <div className="input-group-append">
          <button type="submit" className="btn col-1" onClick={saveEmployee}><i className="bi bi-person-plus-fill"></i></button>
        </div>
      </div>
    </div>
  );
};


export default AddEmployee;