/*import TreeView from "./TreeView";
*/
import UserService from "../../api/UserService";
import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import { useUser } from '../usercontext/UserContext';

function LoginController(props) {
    // React States
    const [errorMessages, setErrorMessages] = useState({});
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [isLogIn, setIsLogIn] = useState(false);
    const [fname, setFName] = useState("");
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const [repass, setRepass] = useState("");
    const [country, setCountry] = useState("");
    const navigate = useNavigate();
    const { userResult, setUserResult } = useUser();

    const errors = {
        uname: "invalid username or password",
        repass: "passwords do not match",
        userex: "user already exists"
    };

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();

        if (isLogIn) {
            UserService.authenticateUser(email, pass).then((result) => {
                result.isSuccessful ? setIsSubmitted(true) : setErrorMessages({ name: "uname", message: errors.uname });
                setUserResult(result.isSuccessful); // Update the shared state
                localStorage.setItem('token', result.isSuccessful);
                localStorage.setItem('email', email);
            });
        }
        else {
            if (pass !== repass) {
                setErrorMessages({ name: "repass", message: errors.repass });
            }
            else {
                UserService.createUser(email, fname, pass, country).then((result) => {
                    result.isSuccessful ? setIsSubmitted(true) : setErrorMessages({ name: "uname", message: errors.userex });
                    setUserResult(result.isSuccessful); // Update the shared state
                    localStorage.setItem('token', result.isSuccessful);
                    localStorage.setItem('email', email);
                });
            }
        }
    };

    // Generate JSX code for error message
    function renderErrorMessage(name) {
        return name === errorMessages.name && (
            <div className="error">{errorMessages.message}</div>
        );
    }

    const renderForm = (
        <div className="container-login">
            <div style={{ transform: `translate(${isLogIn ? 0 : 300}px, 0px)` }} className="form-div">
                <form onSubmit={handleSubmit}>
                    <div> <input placeholder="Email Address" type="text" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </div>
                    <div> <input placeholder="Password" type="password" name="pass" value={pass} onChange={(e) => setPass(e.target.value)} required />
                        {renderErrorMessage("uname")}
                    </div>
                    <div> {isLogIn ? '' :
                        <div><input placeholder="Re-enter password" type="password" name="repass" value={repass} onChange={(e) => setRepass(e.target.value)} required />
                            <input placeholder="Name" type="text" value={fname} onChange={(e) => setFName(e.target.value)} required />
                            <input placeholder="Country of Citizenship" type="text" value={country} onChange={(e) => setCountry(e.target.value)} required />
                            {renderErrorMessage("repass")}
                        </div>}</div>
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
        <div className="login">
            <div className="login-form">
                {//should go to home page after user is logged in
                    isSubmitted ? navigate('/home') : renderForm}
            </div>
        </div>
    );
}

export default LoginController;