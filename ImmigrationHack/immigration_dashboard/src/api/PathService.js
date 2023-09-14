import Service from "./Axios";
import { BASE_URL } from "../Contstants";

const getEligiblePaths = async function (userId) {
   /* const userID = Service.get(`GetEligiblePaths`, { userId }, {});
    Path['userID'] = userID;
    return await userID;*/
    return await Service.get(BASE_URL + `/GetEligiblePaths`, {
        'UserId': userId
    }, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}
/*const getUserInfo = async function (email) {
    return await Service.get(BASE_URL + `/GetUserInfo`, {
        'EmailId': email
    }, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}*/
const getPath = async function (pathId) {
    return await Service.get(`GetPath`, { pathId }, {});
}

// TODO: This only goes one layer deep. This needs to made recursive later
const getPaths = async function (pathIds, forms) {
    let pathResults = await Promise.all(pathIds.map(async (pathId) => {
        return await getPath(pathId);
    }));
    pathResults = pathResults.map((pathResult) => {
        return pathResult.isSuccessful ? pathResult.data : null
    })

    if (pathResults.includes(null)) {
        console.log("Error retrieving paths")
        return {}
    }

    // Make Recursive
    const childPaths = [];
    pathResults.forEach(async (path) => {
        path.pathForms.forEach(async (formId) => {
            const childId = forms.get(formId)?.pathId
            if (childId) {
                const childPathResult = await getPath(childId)
                if (childPathResult.isSuccessful)
                    childPaths.push(childPathResult.data);
            }
        });
    })

    return [...pathResults, ...childPaths]
}

// Temporary placeholder to allow startup
const getPathsTemp = async function (pathIds, forms) {
    return []
}

const PathService = {
    getEligiblePaths
}

const Path = {}

export default PathService;