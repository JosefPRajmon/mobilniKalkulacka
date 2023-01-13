<?php
declare(strict_types=1);

namespace App\Presenters;

class FeedbackPresenter extends Nette\Application\UI\Presenter {
    /** @var \app\Api\FedbackCentr\FeedbackApi @inject */
    public $fedbackApi;

    public function actionSave($title, $feedback) {
        $this->fedbackApi->save($title, $feedback);
        $this->redirect("this");
    }
}

?>