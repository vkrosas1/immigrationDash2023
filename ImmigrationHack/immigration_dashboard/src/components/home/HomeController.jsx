/*import TreeView from "./TreeView";
*/
import UserService from "../../api/UserService";
import React, { useState } from "react";

function HomeController(props) {
    // React States

// Generate UI for displaying path information in the tree view
    function renderPathInfo() {
return (
            <div className="path-info">
                <div className="path-info__title">Path Information</div>
                <div className="path-info__content">
                    <div className="path-info__content__title">Current Path</div>
                    <div className="path-info__content__path">Home</div>
                </div>
            </div>
        );
    }

// Generate UI for displaying the tree view
    function renderTreeView() {
return (
            <div className="tree-view">
                <div className="tree-view__title">Tree View</div>
                <div className="tree-view__content">
                    <TreeView />
                </div>
            </div>
        );
    }

    // Create TreeView 
    function TreeView() {
        const [treeData, setTreeData] = useState([]);
        const [isLoaded, setIsLoaded] = useState(false);
        const [error, setError] = useState(null);

    }

// Generate UI for displaying the file list
    function renderFileList() {
return (
            <div className="file-list">
                <div className="file-list__title">File List</div>
                <div className="file-list__content">
                    <FileList />
                </div>
            </div>
        );
    }

// Create FileList
    function FileList() {
        const [files, setFiles] = useState([]);
        const [isLoaded, setIsLoaded] = useState(false);
        const [error, setError] = useState(null);

    }
    
   
    return (
        <div className="app">
            <div className="login-form">
                <div className="title">Log In</div>
                {renderPathInfo}
            </div>
        </div>
    );
}

export default HomeController;