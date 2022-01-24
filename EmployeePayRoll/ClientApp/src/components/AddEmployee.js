import React, { useState } from "react";
import axios from 'axios';

const AddEmployee = () => {
  const initialEmployee = {
    Id: null,
    Name: "",
    PayPerPeriod: 0,
    TotalPay: 0,
    Deduction: {
      DeductionId: null,
      DeductionAmount: 0,
      TotalDeductionAmount: 0,
      DeductionType: {
        Id: 0,
        Code: "",
        Name: ""
      }
    }
  };

  const [employee, setEmployee] = useState(initialEmployee);

  const handleEmployeeInput = event => {
    debugger;
    const { name, value } = event.target;
    setEmployee({ ...employee, [name]: value });
  };

  const saveEmployee = () => {
    debugger;

    axios.post('api/payroll/create/employee', employee)
      .then(response => {
        setEmployee({
          Id: response.data.Id,
          Name: response.data.Name
        });
        console.log(response.data)
          .catch(e => {
            console.log(e);
          });
      });
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
          id="employeeName"
        />
        <button type="submit" className="btn" onClick={saveEmployee}><i className="bi bi-person-plus-fill"></i></button>
      </div>
    </div>
  );
};


export default AddEmployee;