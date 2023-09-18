import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import React, { useEffect, useState } from "react";
function SettingsController(props) {

    const [userInfo, setUserInfo] = useState([]);
    const [fname, setFName] = useState("");
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const [country, setCountry] = useState("");
    const [isChanged, setIsChanged] = useState(false);


    useEffect(() => {
        const getAllUserInfo = async () => {
            const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
            setUserInfo(getUserInfo.data);
        }; getAllUserInfo();
    }, []);

    const handleSubmit = (event) => {
        //Prevent page reload
        event.preventDefault();

        UserService.updateUserInfo(email, userInfo.name, pass, country,userInfo.id); // Update the shared state

    };

/*     <label for="msg">Comments</label>
                        <textarea id="msg" name="user_message"></textarea>*/
    <input placeholder="Re-enter password" type="password" name="repass" value={pass} onChange={(e) => setPass(e.target.value)} required />

    const renderForm = (
        <div className="App">
            <form className="documentsUpload" onSubmit={handleSubmit}>
                <ul>
                    <li>
                        <label for="userName" required>User name:</label>
                        <input placeholder={userInfo.email} type="text" name="email" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </li>
                    <li>
                        <label for="password">Password:</label>
                        <input placeholder={userInfo.password} type="password" name="repass" value={pass} onChange={(e) => setPass(e.target.value)} />
                    </li>
                    <li>
                        <label for="password">Country Citizenship:</label>
                        <input placeholder={userInfo.citzenCountry} type="text" name="country" value={country} onChange={(e) => setCountry(e.target.value)} />
                    </li>
                    <div>
                        <button>Change Info</button>
                       
                    </div>
                </ul>
            </form>
            
        </div>
    );


    return (
        <div className="userSettings">
            {userInfo.length !== 0 && renderForm }
            <div className="successfulChangeMsg">{isChanged ? <p> Changed the info! </p>: <></>} </div>
        </div>
    );
}

export default SettingsController;