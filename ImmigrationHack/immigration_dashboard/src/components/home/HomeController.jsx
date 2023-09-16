/*import TreeView from "./TreeView";
*/
import { useEffect } from "react";
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import React, { useState } from "react";
import Tree from 'react-d3-tree';
/*import OrgChartTree from "./PathMaker";
*/
/*function formatInput(paths) {
    //let paths = ['GED,OPT,Green Card,Citizenship', 'GED,OPT,H1B,Green Card,Citizenship', 'GED,OPT,F1'];
    let result = [];
    let level = { result };

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
}*/

/*function OrgChartTree(props) {
    //var objToCall = [["GED", "OPT", "Green Card", "Citizenship"], ["GED", "OPT", "H1B", "Green Card", "Citizenship"], ["GED", "OPT", "F1"]];
    //formatInput(objToCall)
    const straightPathFunc = (linkDatum, orientation) => {
        const { source, target } = linkDatum;
        return orientation === 'horizontal'
            ? `M${source.y},${source.x}L${target.y},${target.x}`
            : `M${source.x},${source.y}L${target.x},${target.y}`;
    };

    return (
        <div id="treeWrapper" style={{ width: '50em', height: '20em' }}>
            <Tree
                data={formatInput(props.paths)}
                pathFunc={straightPathFunc}
            />
        </div>
    );
}*/

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
        //let paths = ['GED,OPT,Green Card,Citizenship', 'GED,OPT,H1B,Green Card,Citizenship', 'GED,OPT,F1'];
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

        return (
            <div id="treeWrapper" style={{ width: '50em', height: '20em' }}>
                <Tree
                    data={formatInput(validPaths)}
                    pathFunc={straightPathFunc}
                />
            </div>
        );
    }


    return (
        <div className="app">
            <div className="first part">
                <div className="title">{validPaths}</div>
                <div className="title">{allDocs}</div>
            </div>
            <div className="second part">
                <OrgChartTree />
            </div>
        </div >
    );
}


export default HomeController;