import Service from "./Axios";

const getUser = async function (userId) {
    return await Service.get(`GetUser`, { userId }, {});
}

const UserService = {
    getUser
}

export default UserService;