import { useState } from "react";
import FileService from "../../api/FileService";
import { STATUSES, TEMP_USER } from "../../Contstants";
import DocDropdown from "./DocDropdown";

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

    const documentOptions = [
        { value: "birth certificate", label: "Birth Certificate" },
        { value: "high school diploma", label: "High School Diploma" },
        { value: "permanent residency card", label: "Permanent Residency Card" },
        { value: "n-400", label: "N-400" },
        { value: "marriage license", label: "Marriage License" },
        { value: "passport", label: "Passport" },
        { value: "g1450", label: "G-1450" },
        { value: "g28", label: "G-28" }
    ];

    return (
        <div className="App">
           
            <form action="/my-handling-form-page" method="post">
                <DocDropdown
                    isSearchable
                    isMulti
                    placeHolder="Select..."
                    options={documentOptions}
                    onChange={(value) => console.log(value)}
                />
                <ul>

                    <li>
                        <label for="msg">Comments</label>
                        <textarea id="msg" name="user_message"></textarea>
                    </li>

                    <button type="submit">Upload</button>
                </ul>
            </form>

        </div>
    );
    // create ui that will give a drop down of possible forms to upload and allows the user to input the name of the form
    // and then upload the file to the server

    /*
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
                  {*//*  <div class="column">
<h1 class="is-underlined is-size-3">{props.selectedDocumentForm.id}</h1>
<p class="is-size-5">{props.selectedDocumentForm.data}</p>
</div>*//*}
</div>
<div class="is-flex is-justify-content-end is-align-self-flex-end">
  <button class="button" onClick={onClose}>Close</button>
</div>
</div>
);*/
}

export default DocumentView;