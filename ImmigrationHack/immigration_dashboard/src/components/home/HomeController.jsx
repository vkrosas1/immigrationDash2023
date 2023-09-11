/*import TreeView from "./TreeView";
*/
import React, { useEffect, useState } from "react";

function HomeController(props) {
    // React States
    const [errorMessages, setErrorMessages] = useState({});
    const [isSubmitted, setIsSubmitted] = useState(false);
    const [isLogIn, setIsLogIn] = useState(false);

    // User Login info (sample DB for testing)
    const database = [
        {
            username: "user1",
            password: "pass1"
        },
        {
            username: "user2",
            password: "pass2"
        }
    ];

    const errors = {
        uname: "invalid username",
        pass: "invalid password", 
        repass: "passwords do not match",
        unameex: "username already exists"
    };

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();

        var { uname, pass, repass } = document.forms[0];

        if (isLogIn) {
            // Find user login info
            const userData = database.find((user) => user.username === uname.value);

            // Compare user info
            if (userData) {
                if (userData.password !== pass.value) {
                    // Invalid password
                    setErrorMessages({ name: "pass", message: errors.pass });
                } else {
                    setIsSubmitted(true);
                }
            } else {
                // Username not found
                setErrorMessages({ name: "uname", message: errors.uname });
            }
        }
        else {
            if (database.find((user) => user.username === uname.value)) {
                setErrorMessages({ name: "uname", message: errors.unameex });
            }
            else if (pass.value !== repass.value) {
                setErrorMessages({ name: "repass", message: errors.repass });
            }
            else {
                database.push((user) => user.username === uname.value);
                database.push((user) => user.password === pass.value);

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
            <div style={{ transform: `translate(${isLogIn ? 0 : 250}px, 0px)` }} className="form-div">
                <form onSubmit={handleSubmit}>
                    <div> <input placeholder="Username" type="text" name="uname" required />
                        {renderErrorMessage("uname")}
                    </div>
                    <div> <input placeholder="Password" type="password" name="pass" required />
                        {renderErrorMessage("pass")}
                    </div>
                    <div> {isLogIn ? '' : <input placeholder="Re-enter password" type="password" name="repass" required />}
                        {renderErrorMessage("repass")}</div>
                        <button className="button-primary">Submit</button>
                </form>
            </div>
            <div style={{ transform: `translate(${isLogIn ? 0 : -250}px, 0px)` }} className="button-div">
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