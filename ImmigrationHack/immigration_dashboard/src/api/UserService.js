import { BASE_URL } from "../Contstants";
import Service from "./Axios";

const authenticateUser = async function (email, password) {
    return await Service.get(`AuthenticateUser`, {email, password}, {});
}

const getUserID = async function (email) {
    const userID = Service.get(`getUserID`, { email }, {});
    User['userID'] = userID;
    return await userID;
}

const getUserInfo = async function (userID) {
    return await Service.get(`GetUserAndPass`, { userID }, {});
}

/*function CreateUUID() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    )
}*/
const createUser = async function (email, name, password, country) {
    User['Email'] = email;
    User['Password'] = password;
    User['Name'] = name;
    User['CitizenCountry'] = country;
    User['Id'] = "61ec4094-53f9-413b-fa76-08dbb3e68305";
    return await Service.post(BASE_URL + '/CreateUser', User, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding':'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}

const getUserDocumentForms = async function (userID) {
    return await Service.get(`GetUserDocumentForms`, { userID }, {});
}

const getDocuments = async function (userID) {
    return await Service.get(`GetUserDocuments`, { userID }, {});
}

const createDocument = async function (formId, status) {
    const body = {
        formId,
        status
    }
    return await Service.post(`CreateUserDocument`, body, false);
}

const uploadDocument = async function (formId, status, filename) {
    User['formId'] = formId;
    User['status'] = status;
    User['filename'] = filename;

    return await Service.postFormData(`UploadUserDocument`, User, {});
}

const UserService = {
    createUser,
    authenticateUser,
    getUserID, 
    getUserInfo,
    getDocuments,
    getUserDocumentForms,
    createDocument,
    uploadDocument
}

const User = {}

export default UserService;