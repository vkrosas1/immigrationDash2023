import axios from "axios";
import { BASE_URL } from "../../Contstants";


const server = axios.create({
    baseURL: BASE_URL
});

const get = async function (url, params, headers) {
    const response = server.get(url, {
        params: {
            ...params
        },
        headers: {
            ...headers
        }
    });
    return await handleResponse(response);
}

const post = async function (url, body, isFormEncoded, headers) {
    const response = server.post(url, body, {
        headers: {
            'content-type': isFormEncoded ? 'application/x-www-form-urlencoded' : 'application/json',
            'charset': 'utf-8',
            ...headers
        }
    });
    return await handleResponse(response);
}

const postFormData = async function (url, formData, headers) {
    const response = server.post(url, formData, { headers });
    return await handleResponse(response);
}

const put = async function (url, body, isFormEncoded, headers) {
    const response = server.put(url, body, {
        headers: {
            'content-type': isFormEncoded ? 'application/x-www-form-urlencoded' : 'application/json',
            ...headers
        }
    });
    return await handleResponse(response);
}

const remove = async function (url) {
    const response = server.delete(url);
    return await handleResponse(response);
}

const handleResponse = async function (response) {
    let result;
    try {
        result = await response;
        const responseCode = result && result.status ? result.status.toString(10) : "NO_STATUS";
        if (responseCode.charAt(0) === '2') {
            return {
                data: result.data,
                status: result.status,
                isSuccessful: true
            }
        } else {
            throw new Error('Request Failed');
        }
    } catch (exception) {
        return {
            data: result ? result.data : null,
            status: result ? result.status : 418, // Return result status or I'm a teapot
            isSuccessful: false
        }
    }
}

const Service = {
    get,
    put,
    post,
    postFormData,
    remove
}

export default Service;