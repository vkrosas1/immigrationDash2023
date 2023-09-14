import { Navigate, BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginController from '../login/LoginController';
import HomeController from '../home/HomeController';
import { useUser } from '../usercontext/UserContext';
import DocumentsController from '../documents/DocumentsController';
import FilesController from '../files/FilesController';
import SettingsController from '../settings/SettingsController';
import Header from './Header';


function Layout(props) {
    const { userResult } = useUser(); 

    return (
        <Router>
            <div className="App">
                <div className="container">
                    <Header userResult={userResult} class="block" {...props} />
                    <Routes class="block">
                        {userResult ? ( // Check if user is authenticated
                            <>
                                <Route exact path="/login" element=<LoginController {...props} />></Route>
                                <Route exact path="/home" element=<HomeController {...props} />></Route>
                                <Route exact path="/documents" element=<DocumentsController {...props} />></Route>
                                <Route exact path="/files" element=<FilesController {...props} />></Route>
                                <Route exact path="/settings" element=<SettingsController {...props} />></Route>
                            </>
                        ) : (
                            <Route exact path="/login" element=<LoginController {...props} />></Route>
                        )}

                        {/* Redirect to a default route if none of the conditions match */}
                        <Route path="/" element={<Navigate to="/login" />} />
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default Layout;