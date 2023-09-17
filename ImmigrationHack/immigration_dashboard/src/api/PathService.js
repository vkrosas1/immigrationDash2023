import Service from "./Axios";
import { BASE_URL } from "../Contstants";

const getAllUserDocs = async function (userId) {
    return await Service.get(BASE_URL + `/GetAllDocuments`, {
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

const getEligiblePaths = async function (userId) {
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

const PathService = {
    getAllUserDocs,
    getEligiblePaths
}

const Path = {}

export default PathService;