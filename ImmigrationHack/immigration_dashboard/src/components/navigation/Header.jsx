import { Link } from "react-router-dom";

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
                    <Link style={linkStyle} to="/files">
                        Files
                    </Link>{' '}
                    |{' '}
                    <Link style={linkStyle} to="/settings">
                        Settings
                    </Link>
                </>
            ) : (
                <Link style={linkStyle} to="/login">
                    Login
                </Link>
            )}
        </header>
    );
}

export default Header;