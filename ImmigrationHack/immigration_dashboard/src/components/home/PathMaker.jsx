/*import { useEffect } from "react";
import PathService from "../../api/PathService";
import UserService from "../../api/UserService";
import Tree from 'react-d3-tree';

function formatInput() {
    let paths = ['GED,OPT,Green Card,Citizenship', 'GED,OPT,H1B,Green Card,Citizenship', 'GED,OPT,F1'];
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
}

function OrgChartTree() {
    var objToCall = [["GED", "OPT", "Green Card", "Citizenship"], ["GED", "OPT", "H1B", "Green Card", "Citizenship"], ["GED", "OPT", "F1"]];
    formatInput(objToCall)
    const straightPathFunc = (linkDatum, orientation) => {
        const { source, target } = linkDatum;
        return orientation === 'horizontal'
            ? `M${source.y},${source.x}L${target.y},${target.x}`
            : `M${source.x},${source.y}L${target.x},${target.y}`;
    };

    return (
        <div id="treeWrapper" style={{ width: '50em', height: '20em' }}>
            <Tree
                data={formatInput()}
                pathFunc={straightPathFunc}
            />
        </div>
    );
}

export default OrgChartTree;*/