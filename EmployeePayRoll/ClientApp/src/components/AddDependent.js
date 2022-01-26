import React, { useState } from "react";
import axios from 'axios';

const AddDependent = ({ setDependents, employee }) => {
  const [searchTerm, setSearchTerm] = useState("");

  const dependent = {
    Id: 0,
    EmployeeId: employee.Id,
    Name: "",
    EmployeeName: "",
    DeductionAmount: 0,
    DeductionTypeId: 0,
  };

  const handleDependentInput = event => {
    debugger;
    const searchTerm = event.target.value;
    setSearchTerm(searchTerm);
  };

  const saveDependent = async () => {
    debugger;
    dependent.Name = searchTerm;

    const resp = await axios.post('api/payroll/create/dependent', dependent);
    const allDependents = resp.data;
    setDependents(allDependents);
    setSearchTerm("");
  };

  return (
    <div className="ml-3 row">
      <div className="input-group mb-3 col-3 mr-2">
        <input type="text" className="form-control" name="name" placeholder="Dependent Name" aria-label="Dependent" onChange={handleDependentInput} value={searchTerm} />
        <div className="input-group-append">
          <button type="submit" className="btn col-1" onClick={saveDependent}><i className="bi bi-person-plus-fill"></i></button>
        </div>
      </div>
    </div>
  );
};


export default AddDependent;