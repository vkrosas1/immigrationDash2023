// UserContext.js
import { createContext, useContext, useState } from 'react';

const UserContext = createContext();

export const useUser = () => {
    return useContext(UserContext);
};

export const UserProvider = ({ children }) => {
    const [userResult, setUserResult] = useState(null);

    return (
        <UserContext.Provider value={{ userResult, setUserResult }}>
            {children}
        </UserContext.Provider>
    );
};

