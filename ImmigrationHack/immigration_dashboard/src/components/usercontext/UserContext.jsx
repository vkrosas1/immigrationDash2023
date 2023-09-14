// UserContext.js
import { createContext, useContext, useState } from 'react';

export const UserContext = createContext();
/*const UserContextEmail = createContext();
*/
export const useUser = () => {
    return useContext(UserContext);
};

export const UserProvider = props => {
    const [userResult, setUserResult] = useState(null);
    const [userEmail, setUserEmail] = useState(null);

    return (
        <UserContext.Provider
            value={{ value: [userResult, setUserResult], value2: [userEmail, setUserEmail] }}
        >
            {props.children}
        </UserContext.Provider>
    );
};

/*export const UserProviderEmail = ({ children }) => {
    const[userEmail, setUserEmail] = useState(null);
    return (
        <UserContext.Provider value={{ userEmail, setUserEmail }}>
            {children}
        </UserContext.Provider>
    );
};*/
