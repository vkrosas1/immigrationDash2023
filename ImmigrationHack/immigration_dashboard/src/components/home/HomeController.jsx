/*import TreeView from "./TreeView";
*/
import { useEffect } from "react";
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import React, { useState } from "react";

function HomeController(props) {
    // React States
    const [validPaths, setValidPaths] = useState([]);
    useEffect(() => {
        const getPaths = async () => {
            const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
            console.log(getUserInfo);
            const paths = await PathService.getEligiblePaths(getUserInfo.data.id);
            console.log("got here");
            setValidPaths(paths.data[0]);
            if (paths.data[0]) {
                return "yay got paths";

            }
            return "You haven't added any documents yet";
        }; getPaths();
    }, []);

   
   /* const getDisplay = () => {
        if (!selectedValue || selectedValue.length === 0 || props.hasBeenSubmitted) {
            return props.placeHolder;
        }
        return selectedValue.label;
    };*/

   /* <div className="dropdown-selected-value">{getDisplay()}</div>*/
   
    return (
        <div className="app">
            <div className="login-form">
                <div className="title">{validPaths}</div>
                
            </div>
        </div>
    );
}

export default HomeController;