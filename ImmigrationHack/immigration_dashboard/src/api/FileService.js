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
    return await Service.get(`GetAllForms`, {}, {});
}

const createDocument = async function (userId, formId, status) {
    const body = {
        userId,
        formId,
        status
    }
    return await Service.post(`CreateUserDocument`, body, false);
}

const uploadDocument = async function (userId, formId, status, filename, file) {
    const formData = new FormData();
    formData.append('userId', userId);
    formData.append('formId', formId);
    formData.append('status', status);
    formData.append('filename', filename);
    formData.append('file', file);
    return await Service.postFormData(`UploadUserDocument`, formData, {});
}

const FileService = {
    getUserDocumentForms,
    getForm,
    getDocument,
    createDocument,
    uploadDocument,
    getAllForms
}

export default FileService;