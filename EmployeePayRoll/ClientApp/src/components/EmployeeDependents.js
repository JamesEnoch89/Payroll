////import React, { useState, useEffect } from "react";
////import axios from 'axios';

////const EmployeeDependents = ({ showDependents }) => {
////  debugger;
////  const [dependents, setDependents] = useState([]);
////  const rootEffect = useEffect(null);
////  const [dependentSearchTerm, setDependentSearchTerm] = useState("");

////  if (!showDependents) {
////    return null;
////  }
////  const dependent = {
////    Id: 0,
////    Name: "",
////    DeductionTypeId: 0
////  };

////  rootEffect(() => {
////    debugger;

////    const getDependents = async (employeeId) => {
////      const res = await axios.get(`get/employee/${employeeId}/dependents`);
////      const { data } = await res;

////      setDependents(data);
////    };

////    if (!dependents.length) {
////      getDependents();
////    }
////  }, []);

////  const saveEmployee = async () => {
////    debugger;
////    dependent.Name = dependentSearchTerm;

////    const resp = await axios.post('api/payroll/create/dependent', dependent);
////    const allDependents = resp.data;
////    setDependents(allDependents);
////    setDependentSearchTerm("");
////  };

////  return (
////    <div>
////      <div className="input-group mb-3 col-3 mr-2">
////        <input type="text" className="form-control" placeholder="Dependent Name" aria-label="Dependent" />
////        <div className="input-group-append">
////          <button type="submit" className="btn col-1" onClick={saveEmployee}><i className="bi bi-person-plus-fill"></i></button>
////        </div>
////      </div>

////      <table className="table table-sm table-bordered table-striped">
////        <thead>
////          <tr className="text-center">
////            <th scope="col">Employee Name</th>
////            <th scope="col">Pay <br />Per Period</th>
////            <th scope="col">Total Pay</th>
////            <th scope="col">Deductions <br />Per Period</th>
////            <th scope="col">Total Deductions</th>
////            <th scope="col">Number <br /> of Dependents</th>
////            <th scope="col">View/Add<br /> Dependents</th>
////            <th scope="col">Delete <br />Employee</th>
////          </tr>
////        </thead>
////        {/*<tbody>*/}
////        {/*  {employees.map((employee) => (*/}
////        {/*    <Employee*/}
////        {/*      key={employee.Id}*/}
////        {/*      employee={employee}*/}
////        {/*      showDependents={shouldShowDependents}*/}
////        {/*    />*/}
////        {/*  ))}*/}

////        {/*</tbody>*/}
////      </table>

////    {/*  <EmployeeDependents showDependents={showDependents} />*/}
////    </div>
////  );
////};

////export default EmployeeDependents;