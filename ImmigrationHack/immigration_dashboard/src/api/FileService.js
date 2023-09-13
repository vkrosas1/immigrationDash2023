import Service from "./Axios"

const getUserDocumentForms = async function (userId) {
    return await Service.get(`GetAllUserDocumentForms`, { userId }, {});
}

const getDocument = async function (userId, documentId) {
    const params = {
        documentId,
        userId
    }

    return await Service.get(`GetUserDocument`, params, {});
}

const getForm = async function (formId) {
    return await Service.get(`GetForm`, { formId }, {});
}

const getAllForms = async function () {
    return true; 
    //return await Service.get(`GetAllForms`, {}, {});
}

const createDocument = async function (userId, formId, status) {
    const body = {
        userId,
        formId,
        status
    }
    return await Service.post(`CreateUserDocument`, body, false);
}

const uploadDocument = async function (expirationDate, issueDate, issueCountry, docTypeId, user) {
    Doc['ExpirationDate'] = expirationDate;
    Doc['IssueDate'] = issueDate;
    Doc['IssueCountry'] = issueCountry;
    Doc['DocumentTypeId'] = docTypeId;
    Doc['UserId'] = user.Id;

    return await Service.postFormData(`UploadDocument`, Doc, {});
}

const FileService = {
    getUserDocumentForms,
    getForm,
    getDocument,
    createDocument,
    uploadDocument,
    getAllForms
}
const Doc = {}

export default FileService;