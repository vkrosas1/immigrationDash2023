import Service from "./Axios";

const authenticateUser = async function (email, password) {
    return await Service.get(`AuthenticateUser`, {email, password}, {});
}

const getUserID = async function (email) {
    const userID = Service.get(`getUserID`, { email }, {});
    UserInformation.append('userID', userID);
    return await userID;
}

const getUserInfo = async function (userID) {
    return await Service.get(`GetUserAndPass`, { userID }, {});
}

const createUser = async function (email, password) {
    UserInformation.append('email', email);
    UserInformation.append('password', password);
    return await Service.postFormData(`CreateUserAccount`, UserInformation, {});
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
    UserInformation.append('formId', formId);
    UserInformation.append('status', status);
    UserInformation.append('filename', filename);
    return await Service.postFormData(`UploadUserDocument`, UserInformation, {});
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

const UserInformation = {}

export default UserService;