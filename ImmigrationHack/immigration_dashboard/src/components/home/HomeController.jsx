/*import TreeView from "./TreeView";
*/
import { useEffect } from "react";
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import React, { useState } from "react";
import Tree from 'react-d3-tree';
function HomeController(props) {
    // React States
    const [validPaths, setValidPaths] = useState([]);
    const [allDocs, setAllDocs] = useState([]);

    useEffect(() => {
        const getPaths = async () => {
            const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
            const paths = await PathService.getEligiblePaths(getUserInfo.data.id);
            setValidPaths(paths.data);
            console.log(paths.data);
            return "You haven't added any documents yet";
        }; getPaths();
    }, []);

    useEffect(() => {
        const getAllDocs = async () => {
            const getUserInfo = await UserService.getUserInfo(localStorage.getItem('email'));
            const paths = await PathService.getAllUserDocs(getUserInfo.data.id);
            setAllDocs(JSON.stringify(paths.data[0]));

            return "You haven't added any documents yet";
        }; getAllDocs();
    }, []);

    function formatInput(paths) {
        let result = [];
        let level = { result };
        if (paths.length !== 0) {
            paths.forEach(path => {
                path.split(',').reduce((r, name, i, a) => {
                    console.log("this is r: ", r);
                    if (!r[name]) {
                        r[name] = { result: [] };
                        r.result.push({ name, children: r[name].result })
                    }
                    return r[name];
                }, level)
            })
            return result;
        }


    }

    const OrgChartTree = () => {
        const straightPathFunc = (linkDatum, orientation) => {
            const { source, target } = linkDatum;
            return orientation === 'horizontal'
                ? `M${source.y},${source.x}L${target.y},${target.x}`
                : `M${source.x},${source.y}L${target.x},${target.y}`;
        };

        if (validPaths.length !== 0) {
            return (
                <div id="treeWrapper" style={{ width: '100em', height: '100em', position: 'fixed' }}>
                    <Tree
                        data={formatInput(validPaths)}
                        pathFunc={straightPathFunc}
                        draggable={false}
                    />
                </div>
            );
        } else {
            return (<div>  </div>);
        }
    }


    return (
        <div className="home-pathDiagram">
            <OrgChartTree />
        </div>
    );
}

export default HomeController;