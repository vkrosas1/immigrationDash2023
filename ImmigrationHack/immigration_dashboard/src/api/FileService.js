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

const addDocumentType = async function (docName) { 
    Doc['Name'] = docName;
    return await Service.postFormData(`AddDocumentType`, Doc, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}

const uploadDocument = async function (expirationDate, issueDate, issueCountry, documentType, userId) {
    Doc['ExpirationDate'] = expirationDate;
    Doc['IssueDate'] = issueDate;
    Doc['IssueCountry'] = issueCountry;
    Doc['DocumentType'] = documentType;
    Doc['UserId'] = userId;

    return await Service.postFormData(`UploadDocument`, Doc, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}

const FileService = {
    getUserDocumentForms,
    getForm,
    getDocument,
    createDocument,
    uploadDocument,
    getAllForms,
    addDocumentType
}
const Doc = {}

export default FileService;