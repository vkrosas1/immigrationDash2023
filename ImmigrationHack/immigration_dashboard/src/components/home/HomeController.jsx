/*import TreeView from "./TreeView";
*/
import UserService from "../../api/UserService";
import React, { useState } from "react";

function HomeController(props) {
    // React States
    const [errorMessages, setErrorMessages] = useState({});
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [isLogIn, setIsLogIn] = useState(false);
    const [fname, setFName] = useState(""); 
    const [email, setEmail] = useState(""); 
    const [lname, setLName] = useState(""); 
    const [pass, setPass] = useState(""); 
    const [repass, setRepass] = useState(""); 
    const [country, setCountry] = useState(""); 

    const errors = {
        uname: "invalid username or password",
        repass: "passwords do not match"
    };

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();


        if (isLogIn) {
            // Find user login info
            const userData = UserService.authenticateUser(email, pass);

            // Compare user info
            if (userData) {
                UserService.getUserInfo(email);
            }
            else {
                // Username or password incorrect
                setErrorMessages({ name: "uname", message: errors.uname });
            }
        }
        else {
            if (pass.value !== repass.value) {
                setErrorMessages({ name: "repass", message: errors.repass });
            }
            else {
                UserService.createUser(email, pass, fname, lname, country);
            }
        }
    };

   // Generate JSX code for error message
    function renderErrorMessage(name) {
        return name === errorMessages.name && (
            <div className="error">{errorMessages.message}</div>
        );
    }

    const renderForm =  (
        <div className="container-login">
            <div style={{ transform: `translate(${isLogIn ? 0 : 300}px, 0px)` }} className="form-div">
                <form onSubmit={handleSubmit}>
                    <div> <input placeholder="Email Address" type="text" value={email} onChange={(e) => setEmail(e.target.value)} required />
                        {renderErrorMessage("uname")}
                    </div>
                    <div> <input placeholder="Password" type="password" value={pass} onChange={(e) => setPass(e.target.value)} required />
                        {renderErrorMessage("pass")}
                    </div>
                    <div> {isLogIn ? '' :
                        <div><input placeholder="Re-enter password" type="password" value={repass} onChange={(e) => setRepass(e.target.value)} required />
                            <input placeholder="First Name" type="text" value={fname} onChange={(e) => setFName(e.target.value)} required />
                            <input placeholder="Last Name" type="text" value={lname} onChange={(e) => setLName(e.target.value)} required />
                            <input placeholder="Country of Citizenship" type="text" value={country} onChange={(e) => setCountry(e.target.value)} required />   </div>  }
                        {renderErrorMessage("repass")}</div>
                        <button className="button-primary">Submit</button>
                </form>
            </div>
            <div style={{ transform: `translate(${isLogIn ? 0 : -300}px, 0px)` }} className="button-div">
                <p>{isLogIn ? 'Do not have an account?' : 'Already a member?'}</p>
                <button onClick={() => { setIsLogIn(!isLogIn) }}>{isLogIn ? "Register" : "Log In"}</button>
            </div>
        </div>
    );

    return (
        <div className="app">
            <div className="login-form">
                <div className="title">Log In</div>
                {//should go to landing page after user is logged in
                isSubmitted ? <div>User is successfully logged in</div> : renderForm}
            </div>
        </div>
    );
}

export default HomeController;