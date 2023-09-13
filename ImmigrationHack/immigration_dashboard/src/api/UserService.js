import Service from "./Axios";

const authenticateUser = async function (email, password) {
    return await Service.get(`AuthenticateUser`, {email, password}, {});
}

const getUserID = async function (email) {
    const userID = Service.get(`getUserID`, { email }, {});
    UserInformation['userID'] = userID;
    return await userID;
}

const getUserInfo = async function (email) {
    return await Service.get(`GetUserAndPass`, { email }, {});
}

const createUser = async function (email, password, first_name, last_name, country) {
    UserInformation['email'] = email;
    UserInformation['password'] = password;
    UserInformation['first_name'] = first_name;
    UserInformation['last_name'] = last_name;
    UserInformation['country'] = country;
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
    UserInformation['formId'] = formId;
    UserInformation['status'] = status;
    UserInformation['filename'] = filename;

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