import { BASE_URL } from "../Contstants";
import Service from "./Axios";

const authenticateUser = async function (email, password) {
    User['Email'] = email;
    User['Password'] = password;
    User['Name'] = "";
    return await Service.post(BASE_URL + `/AuthenticateUser`, User, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}

const createUser = async function (email, name, password, country) {
    User['Email'] = email;
    User['Password'] = password;
    User['Name'] = name;
    User['CitizenCountry'] = country;

    return await Service.post(BASE_URL + '/CreateUser', User, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}
const getUserInfo = async function (email) {
    return await Service.get(BASE_URL + `/GetUserInfo`, {
        'EmailId': email
    }, {
        headers: {
            'Accept': 'application/json',
            'Accept- Encoding': 'gzip, deflate, br',
            'Content- Type': 'application / json',
            'Access-Control-Allow-Origin': '*'
        }
    });
}

const updateUserInfo = async function (email, name, password, country, userId) {
    User['Email'] = email;
    User['Name'] = name;
    User['Password'] = password;
    User['Country'] = country;
    User["Id"] = userId;
    return await Service.put(BASE_URL + `/User/` + userId, User);
}

const UserService = {
    authenticateUser,
    createUser,
    getUserInfo,
    updateUserInfo
}

const User = {}

export default UserService;