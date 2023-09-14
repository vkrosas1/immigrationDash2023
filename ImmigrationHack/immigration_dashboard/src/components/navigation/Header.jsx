import { Link } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import { useUser } from '../usercontext/UserContext';

function Header(userResult) {

    const headerStyle = {
        textAlign: 'center',
        background: '#333',
        color: "#fff"
    }

    const linkStyle = {
        color: '#fff',
        textDecoration: 'none'
    }

    const navigate = useNavigate();
    const { userR, setUserResult } = useUser();

    const handleLogout = () => {
        // Clear the authentication token (e.g., from localStorage or cookies)
        localStorage.removeItem('token'); // Replace with your token storage method
        setUserResult(false);
        navigate('/login');
    };

    return (
        <header style={headerStyle}>
            <h1 className="is-size-1">Immigration Dashboard</h1>
            {userResult.userResult ? (
                <>
                    <Link style={linkStyle} to="/home">
                        Home
                    </Link>{' '}
                    |{' '}
                    <Link style={linkStyle} to="/documents">
                        Documents
                    </Link>{' '}
                    |{' '}
                    <Link style={linkStyle} to="/settings">
                        Settings
                    </Link>{' '}
                    |{' '}
                    <Link style={linkStyle} onClick={handleLogout} to="/login">
                        Logout
                    </Link>
                </>
            ) : ''}
        </header>
    );
}

export default Header;