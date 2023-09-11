import { useState } from "react";
import FileService from "../../api/FileService";
import { STATUSES, TEMP_USER } from "../../Constants";

function DocumentView(props) {

    const [file, setFile] = useState(null);
    const [imgSrc, setImgSrc] = useState("https://bulma.io/images/placeholders/320x480.png")
    // const [isLoading, setIsLoading] = useState(true);
    // const [isError, setIsError] = useState(false);

    // useEffect(() => {
    //   async function getDocumentForm() {

    //   }
    //   getDocumentForm();
    // }, [])

    const onChange = (event) => {
        if (event.target.files && event.target.files.length) {
            setFile(event.target.files[0]);
        } else {
            setFile(null);
        }
    }

    const onClose = (event) => {
        setFile(null);
        props.setIsModalOpen(false);
    }

    const onUpload = async (event) => {
        const result = await FileService.uploadDocument(TEMP_USER.id, props.selectedDocumentForm.formId, STATUSES.IN_PROGRESS.key, file.name, file);
        setFile(null)
        props.setIsModalOpen(false);
    }

    return (
        <div class="is-flex is-flex-direction-column">
            <div class="columns">
                <div class="column is-one-third">
                    <figure class="image is-2by3">
                        <img src={imgSrc} alt="File Preview" />
                    </figure>
                    <input type='file' name='Select File' onChange={onChange} />
                    <button class="button " onClick={onUpload}>Upload</button>
                </div>
                <div class="column">
                    <h1 class="is-underlined is-size-3">{props.selectedDocumentForm.id}</h1>
                    <p class="is-size-5">{props.selectedDocumentForm.data}</p>
                </div>
            </div>
            <div class="is-flex is-justify-content-end is-align-self-flex-end">
                <button class="button" onClick={onClose}>Close</button>
            </div>
        </div>
    );
}

export default DocumentView;