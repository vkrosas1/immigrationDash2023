import { useEffect, useState } from 'react';
import './App.css';
import Layout from './components/navigation/Layout';
import { TEMP_USER } from './Contstants';
import FileService from './api/FileService';
import PathService from './api/PathService';

function App() {

    const tempUser = TEMP_USER; // Add temporary hard coded user object

    const [state, setState] = useState({
        user: {},
        paths: {},
        forms: {},
        isLoading: true
    })

    // Get forms and paths
    const getData = async () => {
      /*  setState({
            ...state,
            isLoading: true
        })
        const formResult = await FileService.getAllForms();
        const forms = formResult.isSuccessful ? new Map(formResult.data.map((form) => [form.id, form])) : {}
        if (!forms) {
            console.log("Connection Error")
            setState({
                ...state,
                isLoading: false
            })
            return
        }*/

        // const paths = await PathService.getPaths(tempUser.paths, forms)
    /*    const paths = await PathService.getPathsTemp(tempUser.paths, forms)
        setState({
            ...state,
            forms: forms,
            paths: new Map(paths.map((path) => [path.id, path])),
            user: tempUser,
            isLoading: false
        })*/
    }

    useEffect(() => {
        getData();
    }, [])

    const props = {
        ...state,
        setState
    }

    return <Layout {...props} />

}

export default App;