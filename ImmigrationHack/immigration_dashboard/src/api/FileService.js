import Service from "./Axios"
import { BASE_URL } from "../Contstants";

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
const getDocument = async function (userId, documentId) {
    const params = {
        documentId,
        userId
    }

    return await Service.get(`GetUserDocument`, params, {});
}
const getDocumentTypeByName = async function (docName) { 
    return await Service.get(BASE_URL + `/GetDocumentTypeByName`, {
        'Name': docName
    }, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}
const getUserDocumentForms = async function (userId) {
    return await Service.get(`GetAllUserDocumentForms`, { userId }, {});
}
const uploadDocument = async function (expirationDate, issueDate, issueCountry, documentTypeId, documentType, userId) {
    Doc['ExpirationDate'] = expirationDate;
    Doc['IssueDate'] = issueDate;
    Doc['IssueCountry'] = issueCountry;
    Doc['DocumentTypeId'] = documentTypeId;
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
    addDocumentType,
    getDocument,
    getDocumentTypeByName,
    getUserDocumentForms,
    uploadDocument,
}
const Doc = {}

export default FileService;