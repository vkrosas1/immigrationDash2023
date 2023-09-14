/*import TreeView from "./TreeView";
*/
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import React, { useState } from "react";

function HomeController(props) {
    // React States

    const getPaths = async () => {
        const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
        console.log(getUserInfo);
        const paths = await PathService.getEligiblePaths(getUserInfo.data.id)
        return paths; 
    }
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
                <div className="title">{getPaths()}</div>
                
            </div>
        </div>
    );
}

export default HomeController;